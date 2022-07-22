using P04.BorderControl.Models.Interfaces;

namespace P04.BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Id { get; private set; }

        public string Model { get; private set; }


    }
}
