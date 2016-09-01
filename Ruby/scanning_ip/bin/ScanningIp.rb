require 'ping'
require 'timeout'
require 'socket'

=begin

=end
class ScanningIp
  #
  class << self
    #
    def pingecho(host, timeout=5, service="echo")
      begin
        Timeout.timeout(timeout) do
          s = TCPSocket.new(host, service)
          s.close
        end
      rescue Errno::ECONNREFUSED
        return true
      rescue Timeout::Error, StandardError
        return false
      end
      return true
    end

    #
    def getDataFromConfig(way = "config")
      dataFile = IO.read(way)
      way_ip = /way_ip[\x20]*=[\x20]*([a-zA-Z_\/]+)/.match(dataFile)[1]
      way_port = /way_port[\x20]*=[\x20]*([a-zA-Z\/]+)/.match(dataFile)[1]
      time_interval = /time_interval[\x20]*=[\x20]*([0-9]+)/.match(dataFile)[1]
      log = /log[\x20]*=[\x20]*([a-zA-Z\/]+)/.match(dataFile)[1]
      return :ip_adress => way_ip, :port => way_port, :time_interval => time_interval.to_i, :log => log
    end

    #
    def getPorts(way_port)
      temp = File.readlines(way_port)
      temp.collect{ |x| x.delete "\n" " "}
    end

    #
    def getIpAndAppropriatePorts(way_ip, ports)
      arrayInfoIP = File.readlines(way_ip).collect{|x| x.delete(" ").delete("\n").split("|")}
      very = Hash.new
      arrayInfoIP.each do |x| 
        if(x.count == 3)
          very[x[0]] = x[1].split(",") | ports - x[2].split(",")
        elsif(x.count == 2) 
          very[x[0]] = x[1].split(",") | ports
        else very[x[0]] = ports
        end
      end
      return very
    end

    private :getDataFromConfig, :getIpAndAppropriatePorts, :getPorts

    #
    def start(mode = 1)
      if(mode == 1)
          outputConsoleLog()
      elsif(mode == 2)
        outputFileLog()
      elsif(mode ==3)
	outputFileAndConsoleLog()
      end

    end
   
    #
    def outputConsoleLog()
      configContent = getDataFromConfig()
      pinger = getIpAndAppropriatePorts(configContent[:ip_adress], getPorts(configContent[:port]))
      pinger.each do|key, value| 
        value.each do |port|
          currentTime = Time.new
          if(pingecho(key, configContent[:time_interval], port))
            puts currentTime.inspect + " " + key + ":" + port + " is alive"
          else
            puts currentTime.inspect + " " + key + ":" + port + " is not alive"
          end
        end
      end
    end

    #
    def outputFileLog()
      configContent = getDataFromConfig()
      pinger = getIpAndAppropriatePorts(configContent[:ip_adress], getPorts(configContent[:port]))
      pinger.each do|key, value| 
        value.each do |port|
          currentTime = Time.new
          if(pingecho(key, configContent[:time_interval], port))
            File.open(configContent[:log], 'a') {|file| file.write(currentTime.inspect + " " + key + ":" + port + " is alive\n")}
          else
            File.open(configContent[:log], 'a') {|file| file.write(currentTime.inspect + " " + key + ":" + port + " is not alive\n")}
          end
        end
      end
    end
    
      def outputFileAndConsoleLog()
      configContent = getDataFromConfig()
      pinger = getIpAndAppropriatePorts(configContent[:ip_adress], getPorts(configContent[:port]))
      pinger.each do|key, value| 
        value.each do |port|
          currentTime = Time.new
          if(pingecho(key, configContent[:time_interval], port))
            File.open(configContent[:log], 'a') {|file| file.write(currentTime.inspect + " " + key + ":" + port + " is alive\n")}
	    puts currentTime.inspect + " " + key + ":" + port + " is alive"
          else
            File.open(configContent[:log], 'a') {|file| file.write(currentTime.inspect + " " + key + ":" + port + " is not alive\n")}
	    puts currentTime.inspect + " " + key + ":" + port + " is not alive"
          end
        end
      end
    end
    
    def clearLog()
      configContent = getDataFromConfig()
      File.open(configContent[:log], 'w') {|file| file.write("")}
    end
    
  end
end
