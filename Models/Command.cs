namespace CommandAPI.Models
{
    public class Command
    {

        //Comment set after pulling azure-pipelines.yaml

        public int Id {get; set;}
        public string Howto {get; set;}
        public string Platform {get; set;}
        public string Commandline {get; set;}
    }
}

