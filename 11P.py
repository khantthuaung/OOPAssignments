def average(numbers):
    if not numbers: #if there is no numbers in the list
        return 0
    
    sum = 0
    count = 0
    
    for num in numbers:
        sum += num
        count += 1
    
    return sum / count  

data_values = [2.5, -1.4, -7.2, -11.7, -13.5, -13.5, -14.9, -15.2, -14.0, -9.7, -2.6, 2.1]
student_name = "Khant Thu Aung"
student_id = "105292912"

result = average(data_values)
print(f"Average: {result}")
print(f"Student Name: {student_name}")
print(f"Student ID: {student_id}")

if (result >= 10):
    print("Multiple digits ")
else:
    print("Single digit")

if result < 0:
    print("Average value negative")

#Extract the last digit
last_digit = int(str(result)[-1])
last_digit_id = int(str(student_id)[-1])

if last_digit > last_digit_id:
    print("Larger than my last digit")
elif last_digit < last_digit_id:
    print("Smaller than my last digit")
else:
    print("Equal to my last digit")
