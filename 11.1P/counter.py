class Counter:
    def __init__(self, name):
        self._name = name
        self._count = 0
    
    def increment(self):
        self._count += 1
    
    def reset(self):
        self._count = 0
    
    @property
    def name(self):
        return self._name
    
    @name.setter
    def name(self, value):
        self._name = value
    
    @property
    def ticks(self):
        return self._count
    
    def reset_by_default(self):
        try:
            large_value = 2147483647912
            if large_value > 2147483647:
                self._count = ((large_value - 2147483648) % (2**32)) - 2147483648
            else:
                self._count = large_value
        except:
            # Handle any potential issues
            self._count = 0