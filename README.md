# CS345-Fuzzy-Logic
## Robot Navigation Control 🤖
### 1. Inputs and Outputs for the FLC
#### **Inputs:**
- `Distance (m)` - the distance from the robot to an object
- `Angle (θ)` - the angle of motion of an object with respect to the robot
#### **Output:**
- `Deviation (δ)` - the deviation with respect of the Distance and Angle

### 2.1 Fuzzy Membership Function for the Inputs
- Fuzzy Membership Functions for `Distance`

![Fuzzy Membership Functions for Distance](https://user-images.githubusercontent.com/111884570/206843885-f8ab0445-14d0-4c04-bf39-1716f975d562.png)

- Fuzzy Membership Functions for `Angle`

![Fuzzy Membership Functions for Angle](https://user-images.githubusercontent.com/111884570/206843535-4058cca4-686b-4747-8a42-0573a8ae20e8.png)

### 2.2 Fuzzy Membership Function for Output

- Fuzzy Membership Functions for Output `Deviation`

![image](https://user-images.githubusercontent.com/111884570/206844022-0987be5c-98f2-4f1c-8d5a-3ad904b8aad8.png)

### 3. Fuzzy Rule Base for Output Deviation
Let Distance:
- VN: `Very Near` , NR: `Near` , FR: `Far` , VFR: `Very Far`

Let Angle:
- LT: `Left` , AL: `Ahead Left` , A: `Ahead` , AR: `Ahead Right` , RT: `Right`

| Distance ↓ Angle → |   LT   |   AL   |   A    |   AR   |   RT   |
|:------------------:| :----: | :----: | :----: | :----: | :----: |
|  **VN**            |   A    |   AR   |   AL   |   AL   |   A    |  
|  **NR**            |   A    |   A    |   RT   |   A    |   A    |    
|  **FR**            |   A    |   A    |   AR   |   A    |   A    |     
|  **VFR**           |   A    |   A    |   A    |   A    |   A    |   

``` 
FUZZY LINGUISTIC RULE

IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS NEAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS FAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS VERY_FAR) AND (ANGLE IS LEFT) THEN DEVIATION IS AHEAD

IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD_RIGHT
IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD_LEFT) THEN DEVIATION IS AHEAD

IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD_LEFT
IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS RIGHT
IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD_RIGHT
IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD) THEN DEVIATION IS AHEAD

IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD_LEFT
IF (DISTANCE IS NEAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS FAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS VERY_FAR) AND (ANGLE IS AHEAD_RIGHT) THEN DEVIATION IS AHEAD

IF (DISTANCE IS VERY_NEAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS NEAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS FAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD
IF (DISTANCE IS VERY_FAR) AND (ANGLE IS RIGHT) THEN DEVIATION IS AHEAD
```
