<template>
    <div>
        <h1>Hoc vien:</h1>
        <h2>Ho ten: {{ hoTen }}</h2>
        <h2>Dia chi: {{ diaChi }}</h2>
        <hr />
        <h1>Tro giang:</h1>
        <thong-tin-tro-giang></thong-tin-tro-giang>
    </div>
</template>
<script>
import ThongTinTroGiang from "./ThongTinTroGiang.vue";
export default {
    name: 'thongTinHocSinh',
    components: {
        ThongTinTroGiang,
    },
    data: function() {
        return {
            hoTen: "Nguyen Van A",
            diaChi: "Ha Noi",
        };
    },
};
</script>
