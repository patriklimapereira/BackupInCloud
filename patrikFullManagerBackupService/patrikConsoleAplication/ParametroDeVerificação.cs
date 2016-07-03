using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patrikConsoleAplication {
    class ParametroDeVerificação {
        public long sis_num { get; set; }
        public long fab_num { get; set; }
        public string sis_nome { get; set; }
        public long acs_num { get; set; }
        public long par_num { get; set; }
     //   public long sis_num { get; set; }
      //  public long par_num { get; set; }
        public long usu_num { get; set; }
        public string par_local_backup { get; set; }
        public string par_local_move_backup { get; set; }
        public long par_manter_quantas_versoes { get; set; }
        public string par_extensao_backup { get; set; }
        public DateTime par_hora_de_verificacao { get; set; }
        public DateTime par_modificacaooucriacao { get; set; }
        public bool par_efetuar_verificacao { get; set; }
    }
}
