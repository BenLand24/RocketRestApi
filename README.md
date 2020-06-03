# Rocket_Elevators_Restful_API_Foundation

#### How to use Rocket Elevators REST API using Postman:  
### URL :https://fathomless-meadow-20996.herokuapp.com/  

1. To get all interventions : 

        GET https://fathomless-meadow-20996.herokuapp.com/api/interventions
        SEND
        
2. To get intervention by ID : 
 
        GET https://fathomless-meadow-20996.herokuapp.com/api/interventions/{id}
        SEND
        
3. To modify the status to "InProgress" of specific intervention by id : 
 
        PUT https://fathomless-meadow-20996.herokuapp.com/api/interventions/inprogress/{id}
        SEND
        
4. To modify the status to "Completed" of specific intervention by id : 
 
        PUT https://fathomless-meadow-20996.herokuapp.com/api/interventions/completed/{id}
        SEND
        
