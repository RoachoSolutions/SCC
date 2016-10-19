using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCC.Comun.Clases;

namespace SCC.Couries.RedPack
{
    public class clsInit
    {

        private List<SCC.DAL.Config.couriesconfig> _config = new List<DAL.Config.couriesconfig>();

        public clsInit()
        {
            SCC.DAL.Config.couries _redpack = new DAL.Config.couries();
            using (var context = new SCC.DAL.Config.SCC_ConfigEntities())
            {
                _redpack = context.couries.Where(x => x.idcouries == (int)SCC.Comun.Contantes.Couries.RedPack).FirstOrDefault();
                _config = context.couriesconfig.Where(x => x.idconfig == (int)SCC.Comun.Contantes.Couries.RedPack).ToList();
            }

            if (_redpack.estado > 0)
                throw new Exception("Couries no Activo");

            

        }

        public List<clsTipoEnvio> ObtenerTiposEnvio()
        {
            int idusuario = int.Parse(_config.Where(x => x.clave == "idUsuario").FirstOrDefault().valor);
            string PIN = _config.Where(x => x.clave == "PIN").FirstOrDefault().valor;
            List<clsTipoEnvio> _retValue = new List<clsTipoEnvio>();
            RedPackWs1.RedpackWSPortTypeClient _cliente = new RedPackWs1.RedpackWSPortTypeClient();

            RedPackWs1.Guia[] guias = new RedPackWs1.Guia[1];

            
            guias = _cliente.obtieneCatalogoTipoEntrega(PIN, idusuario);


            foreach(RedPackWs1.Guia _g in guias)
            {
                foreach(RedPackWs1.IdDesc _desc in _g.auxiliar)
                {
                    clsTipoEnvio _tipo = new clsTipoEnvio();
                    _tipo.IdTipo = _desc.id;
                    _tipo.Descripcion = _desc.descripcion;
                    _tipo.Descripcion2 = _desc.equivalencia;

                    _retValue.Add(_tipo);
                }
                
            }

            return _retValue;
        }

        public void Cotizaciones(clsRemitente remitente,clsDestinatario destinatario,clsPaquete paquete,int tipoenvio)
        {
            RedPackWs1.RedpackWSPortTypeClient _cliente = new RedPackWs1.RedpackWSPortTypeClient();
            RedPackWs1.Guia _guia = new RedPackWs1.Guia();

            _guia.remitente = new RedPackWs1.Direccion();
            _guia.remitente.codigoPostal = remitente.Direccion.CP;
            _guia.remitente.codigoPostalSpecified = true;

            _guia.consignatario = new RedPackWs1.Direccion();
            _guia.consignatario.codigoPostal = destinatario.Direccion.CP;
            _guia.consignatario.codigoPostalSpecified = true;

            _guia.tipoEntrega = new RedPackWs1.IdDesc();

            _guia.tipoEntrega.id = tipoenvio;
            _guia.tipoEntrega.idSpecified = true;

        }

    }
}
