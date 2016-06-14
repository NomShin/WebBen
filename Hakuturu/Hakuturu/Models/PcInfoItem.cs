using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;   //追加
using System.ComponentModel.DataAnnotations;   //追加

namespace Hakuturu.Models
{
    public class PcInfoItem
    {
        public int ID { set; get; }   //←これが必要

        [Display(Name = "PC管理番号")]
        public string PcNo { set; get; }
        [Display(Name = "IPアドレス")]
        public string IpAddress { set; get; }
        [Display(Name = "使用区分")]
        public string UseSegment { set; get; }
        [Display(Name = "機種")]
        public string ModelName { set; get; }
        [Display(Name = "型番")]
        public string ModelNo { set; get; }
        [Display(Name = "使用者名")]
        public string UserName { set; get; }
        [Display(Name = "PC名")]
        public string PcName { set; get; }
        [Display(Name = "備考")]
        public string Remarks { set; get; }

    }
    public class PcInfoDBContext : DbContext
    {
        public DbSet<PcInfoItem> PcInfoItems { set; get; }
    }
}