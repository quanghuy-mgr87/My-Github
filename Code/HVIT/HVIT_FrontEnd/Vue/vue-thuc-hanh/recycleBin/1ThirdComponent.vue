<template>
    <div>
        <button @click="changeAge">Change Age</button>
    </div>
</template>
<script>
import { EventBus } from "../main.js";
export default {
    name: "thirdComponent",
    props: ["age_pr"],
    methods: {
        changeAge() {
            this.age_pr = 30;
            EventBus.$emit("ageChanged", this.age_pr);
        },
    },
};
</script>
