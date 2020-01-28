using System;
using System.Collections.Generic;

namespace AddEFCore
{
    public partial class VOrderWithProducts
    {
        public int НомерЗаказа { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Товар { get; set; }
        public decimal Количество { get; set; }
        public decimal? Цена { get; set; }
        public decimal? Сумма { get; set; }
        public string Статус { get; set; }
    }
}
