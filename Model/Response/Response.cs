namespace IDS_Integrador.Model.Response
{
    public abstract class Response : IResponse
    {
        public bool StateExecution {get; set;}  
        public List<string> Messages {get; set;} = new ();
    }
}