from counter import Counter

class Clock:
    def __init__(self):
        self._hour = Counter("Hour")
        self._minute = Counter("Minute")
        self._second = Counter("Second")
    
    def tick(self):
        self._increment_second()
    
    def _increment_second(self):
        self._second.increment()
        if self._second.ticks == 60:
            self._second.reset()
            self._increment_minute()
    
    def _increment_minute(self):
        self._minute.increment()
        if self._minute.ticks == 60:
            self._minute.reset()
            self._increment_hour()
    
    def _increment_hour(self):
        self._hour.increment()
        if self._hour.ticks == 13:
            self._hour.reset()
            self._hour.increment()
    
    def reset(self):
        self._hour.reset()
        self._minute.reset()
        self._second.reset()
    
    def get_time(self):
        return f"{self._hour.ticks:02d}:{self._minute.ticks:02d}:{self._second.ticks:02d}"
    