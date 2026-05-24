using System.Collections.Generic;

namespace LibreriaUniversitariaMVC.Models
{
    public class ReporteInventario
    {
        public ReporteInventario()
        {
            LibrosFiltrados = new List<Libro>();
            LibrosBajoStock = new List<Libro>();
            ResumenCategorias = new List<ResumenCategoria>();
        }

        public string TextoBusqueda { get; set; }
        public int CategoriaId { get; set; }
        public List<Libro> LibrosFiltrados { get; set; }
        public List<Libro> LibrosBajoStock { get; set; }
        public List<ResumenCategoria> ResumenCategorias { get; set; }
        public int TotalLibros { get; set; }
        public int StockTotal { get; set; }
        public decimal ValorInventarioTotal { get; set; }
    }
}
