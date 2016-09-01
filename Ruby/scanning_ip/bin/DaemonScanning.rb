require_relative 'Daemon'
require_relative 'ScanningIp'

=begin

=end
class DaemonScanning < Daemon
  #
  class << self
    #
    def start(mode = 0)
      currentTime = Time.new
      File.open('checking', 'w'){ |file| file.write 'ON' }
      @pid = fork do
        while(checkFile()) do
          ScanningIp.start(2)
        end
      end
    end

    #
    def logger(str)
      File.open('/home/glebmillenium/projects/ruby/lDaemon/Action.log', 'a'){ |file| file.write str }
    end
   
   #
    def checkFile()
      str = File.open('bin/checking', 'r'){ |file| file.read }
      str.eql?("ON")
    end
  end
end
