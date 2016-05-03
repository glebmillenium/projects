require 'timeout'

class Daemon
  def initialize
    puts "from daemon: initializing"
    @cnt = 0
  end

  def main_loop
    @cnt += 1
    puts "from daemon: running loop ##{@cnt}"
    sleep 0.1
  end

  class << self
    def start
      @rd, @wr = IO.pipe
      @pid = fork do
        @rd.close
        running = true
        Signal.trap("TERM") do
          running = false
        end
        begin
          dmn = new
          @wr.write "ok"
          @wr.close
          while running
            dmn.main_loop
          end
        rescue Exception => e
          @wr.write e.to_s
          @wr.close
        ensure
          exit!(1)
        end
      end
      @wr.close
      str = @rd.read
      if str == "ok"
        puts "daemon started ok"
      else
        puts "error while initializing daemon: #{str}"
      end
      @rd.close
    end

    def stop
      unless @pid.nil?
        Process.kill("TERM", @pid)
        @pid = nil
      end
    end

    def running?
      if @pid
        begin
          Timeout::timeout(0.01) do
            Process.waitpid(@pid)
            if $?.exited?
              return false
            end
          end
        rescue Timeout::Error
        end
        return true
      else
        return false
      end
    end
  end
end
