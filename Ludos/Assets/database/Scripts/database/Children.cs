using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[FirestoreData]
public struct Children
{
    [FirestoreProperty]
    public int  ID { get; set; }
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Avatar { get; set; }
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    public int Age { get; set; }

    //Firestore Property to store total_stars
    [FirestoreProperty]
    public int Total_stars { get; set; }
    [FirestoreProperty]
    public int  achievedStars { get; set; }
    //Firestore Property to store Achieved stars
    [FirestoreProperty]
    public List<bool> Achievements { get; set; }
    //Firestore Property to store store_Items 
    [FirestoreProperty]
    public IList StoreItems { get; set; }
    //Firestore Property to store Math 
    [FirestoreProperty]
    public IList Math { get; set; }
    //Firestore Property to store Calendar 
    [FirestoreProperty]
    public IList Calendar { get; set; }
    //Firestore Property to store Animals 
    [FirestoreProperty]
    public IList Animals { get; set; }

    //Firestore Property to store Animals 

    

    public Children(int id, string avatar, string name, int age, int totalStars, int achievedStars, 
        List<bool> achievements, IList storeItems, IList math, IList calendar, IList animals)
    {
        ID = id;
        Avatar = avatar;
        Name = name;
        Age = age;
        Total_stars = totalStars;
        this.achievedStars = achievedStars;
        Achievements = achievements;
        StoreItems = storeItems;
        Math = math;
        Calendar = calendar;
        Animals = animals;
        
    }

    public bool isFirstGame()
    {
        return achievedStars == 0;
    }

    public bool FinishedAllGames()
    {
        Debug.Log(achievedStars);
        return achievedStars >= 54;
    }

    public int getTotalStars(string gameName)
    {
        int stars = 0;
        switch (gameName.ToLower())
        {
            case "math":
                stars = calculateTotalStars(Math, stars);
                break;
            case "calendar":
                stars = calculateTotalStars(Calendar, stars);
                break;
            case "animals":
                stars = calculateTotalStars(Animals, stars);
                break;
        }
        return stars;
    }

    private int calculateTotalStars(IList gameList  , int stars)
    {
        foreach (var level in gameList) stars += System.Convert.ToInt32(level);;
        

        return stars ;
    }

    public bool CheckUnlocked(int index)
    {
        return Achievements[index];
    }
}