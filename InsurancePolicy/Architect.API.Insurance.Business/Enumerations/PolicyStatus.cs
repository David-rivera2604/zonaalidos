namespace Architect.API.Insurance.Business.Enumerations
{
    enum PolicyStatus : int
    {
        Incomplete = 1,
        InReview = 2,
        Declined = 3,
        ToBeAccepted = 4,
        ComplementRequest = 5,
        InForce = 10,
        Cancel = 11
    }
}
