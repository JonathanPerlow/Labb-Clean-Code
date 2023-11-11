namespace Smells
{
    public class Result : IResult
    {
        public void Show()
        {
            var file = Fileformatting();
            Console.WriteLine("Player games average");
            foreach (PlayerData playerData in file)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", playerData.Name, playerData.NGames, playerData.Average()));
            }
        }

        private List<PlayerData> Fileformatting()
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;

            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData playerData = new PlayerData(name, guesses);
                int position = results.IndexOf(playerData);

                if (position < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[position].Update(guesses);
                }
            }

            results.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
            input.Close();

            return results;
        }
    }
}
