package com.aleks.server;


import org.jboss.netty.bootstrap.ServerBootstrap;
import org.jboss.netty.channel.socket.nio.NioServerSocketChannelFactory;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.util.concurrent.Executors;

public class Server
{
    private static final String FIND_ADDRESS = "127.0.0.1";
    private static final int PORT = 7777;

    public Server()
    {
        try
        {
            startup();
        } catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void startup() throws IOException
    {
        ServerBootstrap serverBootstrap;
        serverBootstrap = new ServerBootstrap(new NioServerSocketChannelFactory(Executors.newCachedThreadPool(), Executors.newCachedThreadPool()));
        // serverBootstrap.setPipelineFactory(new PipelineFactory());
        serverBootstrap.bind(new InetSocketAddress(FIND_ADDRESS, PORT));
        System.err.println("Server initialized...");
    }

    public static void main(String[] params)
    {

    }
}
