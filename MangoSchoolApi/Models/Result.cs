﻿namespace MangoSchoolApi.Models
{
    public class Result //Alterar para result e alterar todo o código
    {
        //Fazer alteração
        //Na verdade isso é um result não class
        //Criar tabela, relacionamento de class
        public int Id { get; set; }
        public bool IsActive { get; set; }
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
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
