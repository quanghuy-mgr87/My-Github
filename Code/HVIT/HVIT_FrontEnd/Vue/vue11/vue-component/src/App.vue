<template>
    <div>
        <h1>Root Component</h1>
        <h2>Họ tên: {{ name }}</h2>
        <thong-tin-hoc-sinh :name_pr="name" :changeName="changeName" @nameChanged="nameChangedByChild($event)"></thong-tin-hoc-sinh>
        <sua-thong-tin-hoc-sinh :name_pr="name"></sua-thong-tin-hoc-sinh>
    </div>
</template>
<script>
import SuaThongTinHocSinh from "./components/SuaThongTinHocSinh.vue";
import ThongTinHocSinh from "./components/ThongTinHocSinh.vue";
export default {
    components: {
        SuaThongTinHocSinh,
        ThongTinHocSinh,
    },
    data() {
        return {
            name: "Nguyễn Thu T",
        };
    },
    methods: {
        changeName() {
            this.name = "My (Changed)";
        },
        nameChangedByChild(val) {
            this.name = val;
        },
    },
};
</script>
<style scoped>
div {
    border: 1px double grey;
}
</style>
