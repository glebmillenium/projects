require 'ping'
require 'timeout'
require 'socket'

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

def getDataFromConfig(way = "config")
  dataFile = IO.read(way)
  way_ip = /way_ip[\x20]*=[\x20]*([a-zA-Z_\/]+)/.match(dataFile)[1]
  way_port = /way_port[\x20]*=[\x20]*([a-zA-Z\/]+)/.match(dataFile)[1]
  time_interval = /time_interval[\x20]*=[\x20]*([0-9]+)/.match(dataFile)[1]
  log = /log[\x20]*=[\x20]*([a-zA-Z\/]+)/.match(dataFile)[1]
  return :ip_adress => way_ip, :port => way_port, :time_interval => time_interval.to_i, :log => log
end

def getPorts(way_port)
  temp = File.readlines(way_port)
  temp.collect{ |x| x.delete "\n" " "}
end

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

r = getDataFromConfig()
piner = getIpAndAppropriatePorts(r[:ip_adress], getPorts(r[:port]))
piner.each do|key, value| 
  value.each do |port|
    if(pingecho(key, r[:time_interval], port))
      puts key + ":" + port + " is alive"
    else
      puts key + ":" + port + " is not alive"
    end
  end
end
