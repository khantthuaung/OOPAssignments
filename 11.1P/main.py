from clock import Clock
import os
import psutil

def main():
    second_total = 86400
    my_clock = Clock()
    
    # Run for 3600 seconds (1 hour) first
    for i in range(3600):
        my_clock.tick()
    # Then run for a full day (86400 seconds)
    for i in range(second_total):
        my_clock.tick()
        print(my_clock.get_time())

   
    # Get the current process
    proc = psutil.Process(os.getpid())

    print(f"Current process: {proc}")
    # Display the total physical memory size allocated for the current process
    print(f"Physical memory usage: {proc.memory_info().rss} bytes")
    # Display peak physical memory usage (only available on some platforms)
    try:
        print(f"Peak physical memory usage: {proc.memory_info().peak_wset} bytes")
    except AttributeError:
        print("Peak physical memory usage not supported on this platform.")

if __name__ == "__main__":
    main()