<template>
    <div>
        <h4>First component</h4>
        <p>Name: {{ user.name }}</p>
        <p>Age: {{ user.age }}</p>
        <!-- <second-component :name_pr="user.name" @nameChanged="nameChanged($event)"></second-component> -->
        <second-component :user="user" @nameChanged="nameChanged($event)"></second-component> 
    </div>
</template>
<script>
import SecondComponent from "./SecondComponent.vue";
export default {
    components:{
        SecondComponent,
    },
    name: "firstComponent",
    data: function() {
        return {
            user: {
                name: "Ellie",
                age: 20,
            },
        };
    },
    methods: {
         nameChanged(val){
             this.user.name = val.name;
         }
    },
};
</script>
