package com.aleks.server.util;


import com.aleks.server.net.model.player.Account;

import java.sql.*;

public class MySQL
{

    private static final String SERVER_HOST = "localhost";
    private static final String USER = "root";
    private static final String PASS = "";
    private static final String Database = "TeiruServer";
    private static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    private static final String DB_URL = "jdbc:mysql://" + SERVER_HOST + "/" + Database;
    private static Connection connection;
    private static Statement statement;

    public static ResultSet loadCharacter(Account account, String name)
    {
        try
        {
            CreateConnection();
            String query ="";
            return statement.executeQuery(query);
        }
        catch(SQLException e)
        {
            e.printStackTrace();
        }
        return null;
    }

    public static ResultSet getCharacters(Account account)
    {
        try
        {
            CreateConnection();
            String query = "SELECT * FROM 'Characters' WHERE Owner='"+account.getUsername()+"'";
            return statement.executeQuery(query);
        }
        catch(SQLException e)
        {
            e.printStackTrace();
            CloseConnection();
            return null;
        }
    }

    public static  boolean CreateCharacter(String name)
    {
        try
        {
            CreateConnection();
            String query = "SELECT * FROM 'Characters' WHERE name='"+name+"'";//other sql statement
            ResultSet result = statement.executeQuery(query);
            while(result.next())
            {
                return true;
            }
        }
        catch(SQLException e)
        {
            e.printStackTrace();
            CloseConnection();
            return false;
        }
        CloseConnection();
        return false;
    }


    public static boolean Login(String username , String password)
    {
        try
        {
            CreateConnection();
            String query = "SELECT * FROM 'TeiruServer' WHERE Username='"+username+"' AND Password='"+password+"'";
            ResultSet results = statement.executeQuery(query);
            while (results.next())//select all accounts with this username and password
            {
                CloseConnection();
                return true;
            }
        }
        catch(SQLException e)
        {
            e.printStackTrace();
            CloseConnection();
            return false;
        }
        CloseConnection();
        return false;
    }

    private static void CreateConnection()
    {
        try
        {
            Class.forName(JDBC_DRIVER);
            connection = DriverManager.getConnection(DB_URL, USER, PASS);
            statement = connection.createStatement();
        }
        catch(SQLException | ClassNotFoundException e)
        {
            e.printStackTrace();
        }
    }

    public static boolean CharachetExists(String name)
    {
        try
        {
            CreateConnection();
            String query = "SELECT * FROM 'Characters' WHERE name='"+name+"'";
            ResultSet result = statement.executeQuery(query);
            while(result.next())
            {
                return true;
            }
        }
        catch(SQLException e)
        {
            e.printStackTrace();
            CloseConnection();
            return false;
        }
        CloseConnection();
        return false;
    }

    private static void CloseConnection()
    {
    try
    {
        connection.close();
        statement.close();
    }
    catch(SQLException e)
    {
        e.printStackTrace();
    }
    }

}
