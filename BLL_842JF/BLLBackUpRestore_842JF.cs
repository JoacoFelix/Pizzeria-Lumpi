using DAL_842JF;
using BE_842JF;
using Servicios_842JF.Singleton;

namespace BLL_842JF
{
    public class BLLBackUpRestore_842JF
    {
        BLLBitacoraEvento_842JF bllBitacoraEvento_842JF = new BLLBitacoraEvento_842JF();
        DALBackUpRestore_842JF dalBackUpRestore_842JF = new DALBackUpRestore_842JF();
        public BLLBackUpRestore_842JF()
        {

        }
        public void BackUp_842JF(string ruta)
        {
            dalBackUpRestore_842JF.Backup_842JF(ruta);
            bllBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bllBitacoraEvento_842JF.ObtenerTodos_842JF().Last().idEvento_842JF + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "BackUp", 1));
        }
        public void Restore_842JF(string ruta)
        {
            dalBackUpRestore_842JF.Restore_842JF(ruta);
            bllBitacoraEvento_842JF.RegistrarEvento_842JF(new BEEvento_842JF(bllBitacoraEvento_842JF.ObtenerTodos_842JF().Last().idEvento_842JF + 1, SessionManager_842JF.Instancia.Usuario_842JF.login_842JF, DateTime.Now, "Admin", "Restore", 1));
        }
    }
}
