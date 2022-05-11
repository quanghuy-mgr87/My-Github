<template>
    <div>
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4 pt-5">
                <h2>Bạn quay được số: {{ count }}</h2>
                <button class="btn btn-primary" @click="click">Increase</button>
            </div>
            <div class="col-lg-4"></div>
        </div>
    </div>
</template>
<script>
export default {
    name: "countComponent",
    data: function() {
        return {
            count: 0,
        };
    },
    methods: {
        click() {
            this.count += Math.floor(Math.random() * 10) + 1;
            if (this.count > 100) {
                alert("Bấm ít thôi hỏng chuột bậy giờ!");
            }
        },
    },
};
</script>
<style scoped>
* {
    text-align: center;
}
button:active {
    background-color: peru !important;
}
</style>
