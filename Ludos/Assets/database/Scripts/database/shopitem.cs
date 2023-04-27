using Firebase.Firestore;

[FirestoreData]
public struct shopitem 
{
    [FirestoreProperty]
    public string  Name { get; set; }
    [FirestoreProperty]
    public string Img_path { get; set; }
    [FirestoreProperty]
    public int Price { get; set; }

    public shopitem(string name, string img_path, int price)
    {
        Name = name;
        Img_path = img_path;
        Price = price;
    }
}
