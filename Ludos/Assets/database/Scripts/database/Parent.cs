using Firebase.Firestore;

[FirestoreData]
public struct Parent
{
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    public int NumberOfChildrens { get; set; }
    [FirestoreProperty]
    public string Email { get; set; }
    public Parent(string Name, int NumberOfChildrens, string Email)
    {
        this.Name = Name;
        this.NumberOfChildrens = NumberOfChildrens;
        this.Email = Email;
    }
}