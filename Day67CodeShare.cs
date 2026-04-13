
create one asp .net core mvc application with name AzureSpookyLoginApp

add one model class into the models folder with the name 

using System.ComponentModel.DataAnnotations;

namespace AzureSpookyLogicApp.Models
{
    public class SpookyRequest
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}

