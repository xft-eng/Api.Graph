﻿using System.Collections.Generic;

namespace API.GRAPH
{
    public class Resultado
    {
        public string Acao { get; set; }

        public bool Sucesso
        {
            get { return _Inconsistencias == null || Inconsistencias.Count == 0; }
        }

        private List<string> _Inconsistencias = new List<string>();
        public List<string> Inconsistencias
        {
            get { return _Inconsistencias; }
        }
    }
}