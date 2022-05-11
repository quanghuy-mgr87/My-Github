<template>
    <div>
        <button @click="changeName()">Change Name</button>
    </div>
</template>
<script>
export default {
    props: {
        name_pr: String,
    },
    methods: {
        changeName() {
            this.name_pr = "James";
            this.$emit("nameChanged", this.name_pr);
        },
    },
};
</script>
