require_relative 'bin/Daemon.rb'
require_relative 'bin/DaemonBrightnessMonitor.rb'

data_change = [[00, 00, 300], [10, 00, 300], [12, 00, 300], [18, 00, 300], [20, 00, 300], [23, 00, 300]] 
begin
  t = 160
  if ARGV.length == 1
    if ARGV[0].eql?("--exit") 
      File.open('/home/glebmillenium/projects/ruby/lDaemon/checking', 'w'){ |file| file.write 'OFF' }
    end
  else
    if ARGV.length == 2
      t = ARGV[1] if (ARGV[0].eql?("--value"))
    end
    DaemonBrightnessMonitor.start(t, data_change)
  end
rescue 
  puts "Not right arguments for change monitor brightness"
end
