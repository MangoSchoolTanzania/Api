namespace MangoSchoolApi.ModelView
{
    public class ResultModelView
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string ClassName { get; set; }
        public int ClassYear { get; set; }
        public int ClassMonth { get; set; }

        public string Name { get; set; }
        public int Arith { get; set; }
        public int Kus { get; set; }
        public int HE { get; set; }
        public int SA { get; set; }
        public int Writ { get; set; }
        public int Read { get; set; }
        public int Total { get; set; }
        public int Ave { get; set; }
        public int Pos { get; set; }
    }
}
