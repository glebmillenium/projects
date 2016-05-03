require_relative 'Daemon'

class DaemonBrightnessMonitor < Daemon
  class << self
    def start(parameter, data)
      currentTime = Time.new
      File.open('/home/glebmillenium/projects/ruby/lDaemon/checking', 'w'){ |file| file.write 'ON' }
      @pid = fork do
        while(checkFile()) do
          currentTime = Time.now
          for i in 0...(data.length-1) do
            if(currentTime.to_a[2] > data[i][0] && currentTime.to_a[2] < data[i+1][0])
              File.open('/sys/class/backlight/intel_backlight/brightness', 'w'){ |file| file.write parameter }
              logger(currentTime.inspect  + " Set parametr brightness: " + parameter.to_s + "\n")
            end
          end
        end
      end
    end

    def logger(str)
      File.open('/home/glebmillenium/projects/ruby/lDaemon/Action.log', 'a'){ |file| file.write str }
    end
   
    def checkFile()
      str = File.open('/home/glebmillenium/projects/ruby/lDaemon/checking', 'r'){ |file| file.read }
      str.eql?("ON")
    end
  end
end
