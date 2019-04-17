namespace FastWfcNet.Wfc
{
    public enum ObserveStatus
    {
        /// <summary>
        /// WFC has finished and has succeeded.
        /// </summary>
        Sucess,

        /// <summary>
        /// WFC has finished and failed.
        /// </summary>
        Failure,

        /// <summary>
        /// WFC isn'T finished.
        /// </summary>
        ToContinue
    }
}
