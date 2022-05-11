<template>
    <div>
        <h1>Sửa thông tin học sinh:</h1>
        <h2>Họ tên: {{ hoTen }}</h2>
        <h2>Địa chỉ: {{ diaChi }}</h2>
    </div>
</template>
<script>
import {EventBus} from "../main.js";
export default {
    name: "suaThongTinHocSinh",
    props:{
        name_pr: String,
    },
    data: function() {
        return {
            hoTen: "Nguyen Thi D",
            diaChi: "Ha Noi",
        };
    },
    created() {
        // EventBus.$on("nameChanged", (val) =>{
        //      this.hoTen = val
        // });
        EventBus.$on("nameChanged", this.changed);
    },
    methods: {
        changed(val){
            this.hoTen = val;
        }
    },
};
</script>
<style scoped>
div {
    border: 1px double green;
}
</style>
