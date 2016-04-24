
package retry_release_thread;

import static java.lang.Thread.sleep;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author glebmillenium
 */
public class Retry_release_thread {

    /**
     * @param args the command line arguments
     */
    private static HashMap<String, PulseSignal> container = 
            new HashMap<String, PulseSignal>();
    
    public static void main(String[] args) throws InterruptedException {
        PulseSignal thread = new PulseSignal(1, "Yellow", 3000);
        container.put("12", thread);    // 12 -скорее object можно использовать
        container.get("12").start();
        System.out.println("Запуск потока");
        Thread.sleep(12000);
        container.get("12").interrupt();
        System.out.println("Остановка потока");
    }
}
