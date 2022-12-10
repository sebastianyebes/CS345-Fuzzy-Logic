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
𝗙𝗨𝗭𝗭𝗬 𝗟𝗜𝗡𝗚𝗨𝗜𝗦𝗧𝗜𝗖 𝗥𝗨𝗟𝗘

If (Distance is Very Near) and (Angle is Left) then Deviation is Ahead
If (Distance is Near) and (Angle is Left) then Deviation is Ahead
If (Distance is Far) and (Angle is Left) then Deviation is Ahead
If (Distance is Very Far) and (Angle is Left) then Deviation is Ahead

If (Distance is Very Near) and (Angle is Ahead Left) then Deviation is Ahead Right
If (Distance is Near) and (Angle is Ahead Left) then Deviation is Ahead
If (Distance is Far) and (Angle is Ahead Left) then Deviation is Ahead
If (Distance is Very Far) and (Angle is Ahead Left) then Deviation is Ahead

If (Distance is Very Near) and (Angle is Ahead) then Deviation is Ahead Left
If (Distance is Near) and (Angle is Ahead) then Deviation is Right
If (Distance is Far) and (Angle is Ahead) then Deviation is Ahead Right
If (Distance is Very Far) and (Angle is Ahead) then Deviation is Ahead

If (Distance is Very Near) and (Angle is Ahead Right) then Deviation is Ahead Left
If (Distance is Near) and (Angle is Ahead Right) then Deviation is Ahead
If (Distance is Far) and (Angle is Ahead Right) then Deviation is Ahead
If (Distance is Very Far) and (Angle is Ahead Right) then Deviation is Ahead

If (Distance is Very Near) and (Angle is Right) then Deviation is Ahead
If (Distance is Near) and (Angle is Right) then Deviation is Ahead
If (Distance is Far) and (Angle is Right) then Deviation is Ahead
If (Distance is Very Far) and (Angle is Right) then Deviation is Ahead
```
