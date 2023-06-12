namespace IFM.DataAccess.Models
{
    public enum ModelStatus
    {
        New = 0,
        Modified = 1,
        Deleted = 2,
        FakeAdd = 3,
        FakeEdit = 4,
        FakeDelete = 5
    }

    public enum DataState
    {
        None = 0,
        New = 1,
        Edit = 2
    }

    public enum IfmLanguage
    {
        En = 0,
        Vi = 1
    }

    public enum CpoState
    {
        New = 0,
        Confirmed = 1,
        Working = 2,
        Finished = 3,
        Ship = 4,
        Invoice = 5,
        Paid = 6,
        Debt = 7
    }
}
