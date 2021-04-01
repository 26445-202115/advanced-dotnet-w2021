﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Week10_1_Singleton.Demo
{
    // The 'Singleton' class
    class Singleton

    {
        private static readonly Singleton _instance = new Singleton();
        
        ////Not Thread Safe
        //private static Singleton _instance;

        // Constructor is 'private'
        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            ////Not Thread Safe
            //if (_instance == null)
            //{
            //    _instance = new Singleton();
            //}

            return _instance;
        }
    }

}
