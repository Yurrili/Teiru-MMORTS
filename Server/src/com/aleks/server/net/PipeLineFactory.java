package com.aleks.server.net;


import com.aleks.server.net.codecs.Encoder;
import com.aleks.server.net.codecs.LoginServerDecoder;
import org.jboss.netty.channel.ChannelPipeline;
import org.jboss.netty.channel.ChannelPipelineFactory;
import org.jboss.netty.channel.DefaultChannelPipeline;

public class PipeLineFactory implements ChannelPipelineFactory
{
    @Override
    public ChannelPipeline getPipeline() throws Exception
    {
        ChannelPipeline pipeline = new DefaultChannelPipeline();
        pipeline.addLast("encoder", new Encoder());
        pipeline.addLast("decoder", new LoginServerDecoder());
        return pipeline;
    }
}
