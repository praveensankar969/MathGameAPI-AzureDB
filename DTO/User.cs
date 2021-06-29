using System;

namespace MathGameAPI.DTO
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int HighScore {get; set;}
        public int CurrentScore {get; set;}
    }
}