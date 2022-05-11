<template>
    <div>
        <h4>First Component</h4>
        <p>Name: {{ user.name }}</p>
        <p>Age: {{ user.age }}</p>
        <second-component :user_pr="user"></second-component>
    </div>
</template>
<script>
import SecondComponent from "./1SecondComponent.vue";
import { EventBus } from "../main.js";
export default {
    name: "firstComponent",
    components: {
        SecondComponent,
    },
    data: function() {
        return {
            user: {
                name: "Ellie",
                age: 20,
            },
        };
    },
    created() {
        EventBus.$on("ageChanged", this.ageChanged);
    },
    methods: {
        ageChanged(val) {
            this.user.age = val;
        },
    },
};
</script>
