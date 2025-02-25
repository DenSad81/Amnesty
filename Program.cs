using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        List<Criminal> criminals = new List<Criminal>();
        CriminalsCreater createrOfCriminals = new CriminalsCreater();

        criminals = createrOfCriminals.CreateCriminals(random);
        Console.WriteLine("Before amnesty");
        ShowCriminals(criminals);
        int quantityCriminalsBeforAmnesty = criminals.Count;

        Searcher search = new Searcher();
        criminals = search.GoExceptAntyguwernement(criminals);
        Console.WriteLine("After amnesty");
        ShowCriminals(criminals);
        int quantityCriminalsAfterAmnesty = criminals.Count;

        Console.WriteLine("Before amnesty: " + quantityCriminalsBeforAmnesty);
        Console.WriteLine("After amnesty: " + quantityCriminalsAfterAmnesty);
    }

    public static void ShowCriminals(List<Criminal> criminals)
    {
        foreach (var criminal in criminals)
            criminal.ShowData();
    }
}

public class Criminal
{
    public Criminal(Names name, Nationalitys nationality, Articles article, int growth, int weigfh, bool isFree)
    {
        Name = name;
        Nationality = nationality;
        Growth = growth;
        Weight = weigfh;
        Id = IDS++;
        IsFree = isFree;
        Article = article;
    }

    public static int IDS { get; private set; } = 0;
    public int Id { get; private set; }
    public Names Name { get; private set; }
    public Nationalitys Nationality { get; private set; }
    public Articles Article { get; private set; }
    public int Growth { get; private set; }
    public int Weight { get; private set; }
    public bool IsFree { get; private set; }

    public void ShowData() =>
        Console.WriteLine($"ID: {Id} Name: {Name} Nationality: {Nationality} Article: {Article} Growth: {Growth} Weight: {Weight} Is free: {IsFree}");
}

public class CriminalsCreater
{
    public List<Criminal> CreateCriminals(Random random)
    {
        int minGrowth = 170;
        int maxGrowth = 200;
        int minWeight = 60;
        int maxWeight = 120;
        int quantityOfCriminals = 1000000;
        List<Criminal> criminals = new List<Criminal>();

        for (int i = 0; i < quantityOfCriminals; i++)
        {
            Names tempName = (Names)random.Next(0, (int)Names.MaxValue);
            Nationalitys tempNationality = (Nationalitys)random.Next(0, (int)Nationalitys.MaxValue);
            Articles tempArticle = (Articles)random.Next(0, (int)Articles.MaxValue);
            int tempGrowth = random.Next(minGrowth, maxGrowth);
            int tempWeight = random.Next(minWeight, maxWeight);
            bool tempIsFree = Convert.ToBoolean(random.Next(0, 2));

            criminals.Add(new Criminal(tempName, tempNationality, tempArticle, tempGrowth, tempWeight, tempIsFree));
        }

        return criminals;
    }
}

public enum Names
{
    Pavel,
    Boris,
    Ken,
    Ben,
    Alex,
    Petr,
    Ger,
    MaxValue
}

public enum Nationalitys
{
    Greese,
    Russian,
    Germanis,
    Indian,
    Chainasis,
    Ucrain,
    MaxValue
}

public enum Articles
{
    Antyguwernement,
    Murder,
    Robbery,
    Fire,
    Drugs,
    Guns,
    Sex,
    MaxValue
}

public class Searcher
{
    public List<Criminal> GoExceptAntyguwernement(List<Criminal> criminals)
    {
        IEnumerable<Criminal> filtredCriminals = criminals.Where(element => element.Article != Articles.Antyguwernement || (element.Article == Articles.Antyguwernement && element.IsFree == true));
        return filtredCriminals.ToList();
    }
}