Dictionary<string, Dictionary<string, int>> dctFruits = new Dictionary<string, Dictionary<string, int>>();
Dictionary<string, int> dctFruit = new Dictionary<string, int>
{
    { "PerTree", 400 },
    { "Days", 10 },
    { "Kg", 5 },
    { "Rs", 150 },
};
dctFruits.Add("Apple", dctFruit);
dctFruit = new Dictionary<string, int>
{
    { "PerTree", 280 },
    { "Days", 6 },
    { "Kg", 7 },
    { "Rs", 250 },
};
dctFruits.Add("Orange", dctFruit);
dctFruit = new Dictionary<string, int>
{
    { "PerTree", 2200 },
    { "Days", 15 },
    { "Kg", 8 },
    { "Rs", 100 },
};
dctFruits.Add("Mango", dctFruit);
dctFruit = new Dictionary<string, int>
{
    { "PerTree", 1500 },
    { "Days", 5 },
    { "Kg", 10 },
    { "Rs", 50 },
};
dctFruits.Add("Lemon", dctFruit);
dctFruit = new Dictionary<string, int>
{
    { "PerTree", 75 },
    { "Days", 15 },
    { "Kg", 15 },
    { "Rs", 1600 },
};
dctFruits.Add("Coconut", dctFruit);

using (StreamReader sr = new StreamReader("../../../Large_Input.txt"))
{
    int n = Convert.ToInt32(sr.ReadLine());
    int Count = 1;
    while (n-- > 0)
    {
        string[] data = sr.ReadLine().Split(' ', '\t');
        int Trees = Convert.ToInt32(data[0]);
        int Days = Convert.ToInt32(data[1]);
        int NetProfit = GetMaxprofit(Trees, Days);
        Console.WriteLine("Case #" + Count++ + ": " + NetProfit);
    }
}
int GetMaxprofit(int Trees, int Days)
{
    List<int> lstProfits = new List<int>();
    foreach (string Key in dctFruits.Keys)
    {
        dctFruits[Key]["Multiply"] = Days / dctFruits[Key]["Days"];
        dctFruits[Key]["TotalQuantity"] = dctFruits[Key]["Multiply"] * dctFruits[Key]["PerTree"];
        dctFruits[Key]["TotalKg"] = dctFruits[Key]["TotalQuantity"] / dctFruits[Key]["Kg"];
        dctFruits[Key]["TotalProfit"] = dctFruits[Key]["TotalKg"] * dctFruits[Key]["Rs"];
        lstProfits.Add(dctFruits[Key]["TotalProfit"]);
    }
    lstProfits = lstProfits.OrderByDescending(x => x).ToList();
    int PlantTrees = Trees;
    if (Trees - 5 > 0)
    {
        int Tree40 = Convert.ToInt32(Trees * 0.4);
        int index = 0;
        while (PlantTrees > 0)
        {
            if (Tree40 > PlantTrees)
            {
                lstProfits[index++] *= PlantTrees;
                PlantTrees = 0;
            }
            else
            {
                lstProfits[index++] *= Tree40;
                PlantTrees -= Tree40 + 1;
            }
        }

    }
    return lstProfits.Sum();
}