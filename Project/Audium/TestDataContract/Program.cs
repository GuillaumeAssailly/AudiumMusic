﻿using Gestionnaires;
using System;
using Stub;


namespace TestDataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager LeManager = new Manager(new Stub.Stub());
         
    
            LeManager.Persistance = new DataContractPersistance.DataContractPers();
            LeManager.SauvegardeDonnees();
        
            Manager LeManager2 = new Manager(new DataContractPersistance.DataContractPers());
           
        



        }
    }
}