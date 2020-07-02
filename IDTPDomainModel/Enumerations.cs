namespace IDTPDomainModel
{

    public enum EntityState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

    public enum WorkflowState
    {
        Open,
        Closed
    }

    public enum ApplicationStatus
    {
        Open,
        Closed
    }

    public enum RequestIncumbentStatus
    {
        Open,
        Closed
    }
}
