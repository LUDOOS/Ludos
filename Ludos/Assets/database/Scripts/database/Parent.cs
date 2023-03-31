using Firebase.Firestore;

[FirestoreData]
public struct Parent
{
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    public int NoChildren { get; set; }

    [FirestoreProperty]
    public string Email { get; set; }
    public Parent(string Name, int NoChildren, string Email)
    {
        this.Name = Name;
        this.NoChildren = NoChildren;
        this.Email = Email;
    }
}