require_relative 'bin/ScanningIp'
require_relative 'bin/DaemonScanning'

def outputHelp()
 File.open('data/help', 'r') { |file| puts file.read }
end

unless(ARGV.include? "--off")
  mode = 1
  daemon = ARGV.include? "--daemon"
  if(ARGV.include? "--mode")
    mode = ARGV[ARGV.index("--mode") + 1].to_i
  end
  if(ARGV.length == 1)
    if(ARGV.include?("--help")) 
      outputHelp(); 
      exit;
    end

    if(ARGV.include?("--clear"))
      ScanningIp.clearLog(); 
      exit;
    end
  end
  if(daemon)
    DaemonScanning.start
  else
    startingScanning = Thread.new do
      while(true) do
        ScanningIp.start(mode)
      end
    end
    Signal.trap("EXIT", proc {terminate})
    sleep
  end
else
 File.open('bin/checking', 'w') {|file|  file.write "OFF" }
end
