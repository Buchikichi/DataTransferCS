using System;
using System.Windows.Forms;

namespace DataTransfer.Data
{
    public enum ConnectionType
    {
        MSAccess = 0,
        PostgreSQL = 5432,
    }

    public class ConnectionTypeUtil
    {
        public static void SetupComboBox(ComboBox comboBox)
        {
            foreach (var type in Enum.GetValues(typeof(ConnectionType)))
            {
                comboBox.Items.Add(type);
            }
            comboBox.SelectedItem = ConnectionType.PostgreSQL;
        }

        private ConnectionTypeUtil() { }
    }
}
