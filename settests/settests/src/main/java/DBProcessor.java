
import com.mysql.fabric.jdbc.FabricMySQLDriver;
import com.mysql.jdbc.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBProcessor {
    private Connection connection;

    public DBProcessor() throws SQLException {
        DriverManager.registerDriver(new FabricMySQLDriver());
    }

    public Connection getConnection(String url, String username, String password) throws SQLException {
        if(this.connection != null) {
            return this.connection;
        } else {
            this.connection = (Connection)DriverManager.getConnection(url, username, password);
            return this.connection;
        }
    }
}
