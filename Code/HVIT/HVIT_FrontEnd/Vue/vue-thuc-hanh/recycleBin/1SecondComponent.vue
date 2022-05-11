<template>
    <div>
        <third-component :age_pr="user_pr.age"></third-component>
    </div>
</template>
<script>
import ThirdComponent from "./1ThirdComponent.vue";
export default {
    name: "secondComponent",
    components: {
        ThirdComponent,
    },
    props: {
        user_pr: Object,
    },
};
</script>
